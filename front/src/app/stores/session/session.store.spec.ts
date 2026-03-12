import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { of } from 'rxjs';

import { IAuthentifiedUser } from '../../models';
import { AuthService } from '../../services';
import { SessionStore } from './session.store';

describe('SessionStore', () => {
	const storedSession = { token: 'token', userId: 7 };
	const authentifiedUser: IAuthentifiedUser = { token: 'token', userId: 12 };
	let authServiceSpy: jasmine.SpyObj<AuthService>;
	let routerSpy: jasmine.SpyObj<Router>;

	beforeEach(() => {
		authServiceSpy = jasmine.createSpyObj<AuthService>('AuthService', [
			'clearSession',
			'loginAsync',
			'readStoredSession',
			'signupAsync',
			'storeSession'
		]);
		routerSpy = jasmine.createSpyObj<Router>('Router', ['navigate']);

		authServiceSpy.readStoredSession.and.returnValue(storedSession);
		authServiceSpy.loginAsync.and.returnValue(of(authentifiedUser));
		authServiceSpy.signupAsync.and.returnValue(of(authentifiedUser));
		routerSpy.navigate.and.resolveTo(true);

		TestBed.configureTestingModule({
			providers: [
				SessionStore,
				{ provide: AuthService, useValue: authServiceSpy },
				{ provide: Router, useValue: routerSpy }
			]
		});
	});

	it('hydrates from stored session on initialization', () => {
		const store = TestBed.inject(SessionStore);

		expect(store.isAuthenticated()).toBeTrue();
		expect(store.userId()).toBe(7);
		expect(store.playersRoute()).toEqual(['/users', 7, 'players']);
	});

	it('logs in through the auth service and updates shared session state', async () => {
		const store = TestBed.inject(SessionStore);

		await store.login({ userName: 'player', password: 'secret' });

		expect(authServiceSpy.storeSession).toHaveBeenCalledWith(authentifiedUser);
		expect(store.isAuthenticated()).toBeTrue();
		expect(store.userId()).toBe(12);
		expect(routerSpy.navigate).toHaveBeenCalledWith(['/users', 12, 'players']);
	});
});