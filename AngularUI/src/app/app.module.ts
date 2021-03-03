import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContaspagarComponent } from './contaspagar/contaspagar.component';
import { CpAddEditComponent } from './contaspagar/cp-add-edit/cp-add-edit.component';
import { CpShowDeleteComponent } from './contaspagar/cp-show-delete/cp-show-delete.component';
import {SharedService} from './shared.service';
import {HttpClientModule} from '@angular/common/http'
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { ContaspagasComponent } from './contaspagas/contaspagas.component';
import { CpPaymentComponent } from './contaspagar/cp-payment/cp-payment.component';

@NgModule({
  declarations: [
    AppComponent,
    ContaspagarComponent,
    CpAddEditComponent,
    CpShowDeleteComponent,
    ContaspagasComponent,
    CpPaymentComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
