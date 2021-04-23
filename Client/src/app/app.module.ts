import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { TaxFormComponent } from './tax-form/tax-form.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports:      [ BrowserModule, AppRoutingModule, CoreModule, ReactiveFormsModule ],
  declarations: [ AppComponent, AppRoutingModule.components, TaxFormComponent ],
  bootstrap:    [ AppComponent ]
})
export class AppModule { }
