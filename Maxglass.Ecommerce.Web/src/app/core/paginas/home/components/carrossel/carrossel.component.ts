import { Component, OnInit } from '@angular/core';
import { CarouselConfig } from 'ngx-bootstrap/carousel';

@Component({
  selector: 'app-carrossel',
  templateUrl: './carrossel.component.html',
  styleUrls: ['./carrossel.component.css']
})
export class CarrosselComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  providers: [
    { provide: CarouselConfig, useValue: { interval: 1200, noPause: true, showIndicators: true } }
  ]

}
