import { HttpErrorResponse } from '@angular/common/http';
import { computed, inject } from '@angular/core';
import { Router } from '@angular/router';
import { patchState, signalStore, withComputed, withHooks, withMethods, withState } from '@ngrx/signals';
import { firstValueFrom } from 'rxjs';

import { ILoginPayload } from '../../models';
import { IUserPayload } from '../../models/users.models';
import { AuthService, StoredSession } from '../../services';

interface SessionState {
	isAuthenticated: boolean;
	userId: number | null;
	isHydrated: boolean;
	isSubmitting: boolean;
	authError: HttpErrorResponse | null;
}

const initialState: SessionState = {
	isAuthenticated: false,
	userId: null,
	isHydrated: false,
	isSubmitting: false,
	authError: null
};

function buildSessionState(session: StoredSession): Pick<SessionState, 'isAuthenticated' | 'userId' | 'isHydrated'> {
	return {
		isAuthenticated: session.token !== null && session.userId !== null,
		userId: session.userId,
		isHydrated: true
	};
}

function normalizeAuthError(error: unknown): HttpErrorResponse | null {
	return error instanceof HttpErrorResponse ? error : null;
}

export const SessionStore = signalStore(
	{ providedIn: 'root' },
	withState(initialState),
	withComputed(({ userId }) => ({
		playersRoute: computed(() => {
			const currentUserId = userId();
			return currentUserId === null ? ['/'] : ['/users', currentUserId, 'players'];
		})
	})),
	withMethods((store, authService = inject(AuthService), router = inject(Router)) => ({
		hydrateFromStorage(): void {
			patchState(store, {
				...buildSessionState(authService.readStoredSession()),
				authError: null,
				isSubmitting: false
			});
		},

		clearSessionState(): void {
			patchState(store, {
				...initialState,
				isHydrated: true
			});
		},

		async login(loginPayload: ILoginPayload): Promise<void> {
			patchState(store, { authError: null, isSubmitting: true });

			try {
				const authentifiedUser = await firstValueFrom(authService.loginAsync(loginPayload));

				if (authentifiedUser === null) {
					patchState(store, { isSubmitting: false });
					return;
				}

				authService.storeSession(authentifiedUser);
				patchState(store, {
					isAuthenticated: true,
					userId: authentifiedUser.userId,
					isHydrated: true,
					isSubmitting: false,
					authError: null
				});

				await router.navigate(['/users', authentifiedUser.userId, 'players']);
			} catch (error) {
				patchState(store, {
					authError: normalizeAuthError(error),
					isSubmitting: false,
					isHydrated: true
				});
			}
		},

		async signup(userPayload: IUserPayload): Promise<void> {
			patchState(store, { authError: null, isSubmitting: true });

			try {
				const authentifiedUser = await firstValueFrom(authService.signupAsync(userPayload));

				if (authentifiedUser === null) {
					patchState(store, { isSubmitting: false });
					return;
				}

				authService.storeSession(authentifiedUser);
				patchState(store, {
					isAuthenticated: true,
					userId: authentifiedUser.userId,
					isHydrated: true,
					isSubmitting: false,
					authError: null
				});

				await router.navigate(['/users', authentifiedUser.userId, 'players']);
			} catch (error) {
				patchState(store, {
					authError: normalizeAuthError(error),
					isSubmitting: false,
					isHydrated: true
				});
			}
		},

		async logoutToLogin(): Promise<void> {
			authService.clearSession();
			patchState(store, {
				...initialState,
				isHydrated: true
			});

			await router.navigate(['/login']);
		}
	})),
	withHooks({
		onInit(store, authService = inject(AuthService)) {
			patchState(store, buildSessionState(authService.readStoredSession()));
		}
	})
);