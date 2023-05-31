import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';
import { HomepageComponent } from './Components/homepage/homepage.component';
import { HotelComponent } from './services/hotel/hotel.component';

@NgModule({
  declarations: [
    AppComponent,
    CheckoutComponent,
    HomepageComponent,
    HotelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
