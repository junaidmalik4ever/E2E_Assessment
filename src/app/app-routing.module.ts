import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { CheckoutPageComponent } from './Components/checkout-page/checkout-page.component';

const routes: Routes = [
  {path:'',redirectTo: 'hotel',pathMatch:'full'},
  {path:'Hotel',component:HomePageComponent},
  {path:'Hotel/checkout',component:CheckoutPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
