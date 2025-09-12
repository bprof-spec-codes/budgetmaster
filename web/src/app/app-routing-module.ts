import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Test } from './test/test';
import { Createtransaction } from './createtransaction/createtransaction';

const routes: Routes = [
  {path:'', component:Test, pathMatch: 'full'},
  {path:'create', component:Createtransaction, pathMatch: 'full'},
  {path:'**', redirectTo:'', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
