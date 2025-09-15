import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Test } from './test/test';
import { HttpClientModule } from '@angular/common/http';
import { Createtransaction } from './createtransaction/createtransaction';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    Test,
    Createtransaction
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  bootstrap: [App]
})
export class AppModule { }
