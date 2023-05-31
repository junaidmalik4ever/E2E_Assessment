import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/Models/restaurant';
import { RestroService } from 'src/app/Services/restro.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  hotels: Hotel[] = [];
  number :number = 0;
  constructor(private restroService: RestroService) {}

  ngOnInit() {

    this.restroService.getAllMenu().subscribe((data : Restaurant[]) => {

      this.hotels = data;

    });

  }

  addToCheckout(restaurant: any) {
    
    this.number = this.number +1;
    alert(restaurant.itemname+' Added to Checkout ');
    this.restroService.addToCheckout(restaurant);

  }
}
