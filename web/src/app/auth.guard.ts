import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {

	const auth = inject(AuthService)
	const router = inject(Router)

	// 1) be van-e jelentkezve (exp alapján is)
	if (!auth.isLoggedIn()) {
		console.log("AuthGuard activated")
		router.navigate(['/login'], { queryParams: { returnUrl: state.url } })
		return false;
	}



	return true;
};
