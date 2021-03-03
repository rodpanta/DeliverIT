import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import{ContaspagarComponent} from './contaspagar/contaspagar.component';
import{ContaspagasComponent} from './contaspagas/contaspagas.component';
import {CpAddEditComponent} from './contaspagar/cp-add-edit/cp-add-edit.component';
import {CpPaymentComponent} from './contaspagar/cp-payment/cp-payment.component';
 

const routes: Routes = [

  {path: 'contaspagar', component:ContaspagarComponent},
  {path: 'contaspagas', component:ContaspagasComponent},
  {path: 'contaspagar/create', component:CpAddEditComponent},
  {path: 'contaspagar/edit/:id', component:CpAddEditComponent},
  {path: 'contaspagar/payment/:id', component:CpPaymentComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }