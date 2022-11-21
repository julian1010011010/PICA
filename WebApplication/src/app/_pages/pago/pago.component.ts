import { Component, OnInit } from '@angular/core';

export interface Tile {
  cols: number;
  rows: number;
  img: string;
}

@Component({
  selector: 'app-pago',
  templateUrl: './pago.component.html',
  styleUrls: ['./pago.component.scss']
})
export class PagoComponent implements OnInit {

  tiles: Tile[] = [
    {img: 'ffie3.jpg', cols: 3, rows: 1},
    {img: 'ffie2.jpg', cols: 1, rows: 2},
    {img: 'ffie1.jpg', cols: 1, rows: 1},
    {img: 'ffie4.jpg', cols: 2, rows: 1},
  ];

  constructor(
  ) {

  }

  ngOnInit(): void {

  }

}
