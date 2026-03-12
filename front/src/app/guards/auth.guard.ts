import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { SessionStore } from '../stores';

export const authGuard: CanActivateFn = () => {
	const sessionStore = inject(SessionStore);

	if (!sessionStore.isAuthenticated()) {
		return true;
	}

	return inject(Router).createUrlTree(sessionStore.playersRoute());
};