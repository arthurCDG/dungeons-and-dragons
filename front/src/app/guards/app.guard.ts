import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { SessionStore } from '../stores';

export const appGuard: CanActivateFn = () => {
	const sessionStore = inject(SessionStore);

	if (sessionStore.isAuthenticated()) {
		return true;
	}

	return inject(Router).createUrlTree(['/login']);
};