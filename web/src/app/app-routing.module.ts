import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';

const routes: Routes = [
	{path: '', component: HomeComponent},
	{path: 'home', component: HomeComponent},
	{ path: 'login', component: LoginComponent },
    { path: 'logout', component: LogoutComponent },
	
	{path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule {


 }
