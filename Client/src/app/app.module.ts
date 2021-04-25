import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { CoreModule } from './core/core.module';
import { TaxFormComponent } from './tax-form/tax-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCurrencyFormatModule } from 'mat-currency-format';
import { CommonModule } from '@angular/common';
@NgModule({
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    ReactiveFormsModule,
    MatCurrencyFormatModule,
    CommonModule
  ],
  declarations: [AppComponent, AppRoutingModule.components, TaxFormComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
