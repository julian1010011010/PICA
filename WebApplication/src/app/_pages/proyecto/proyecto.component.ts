import { Component, OnInit } from '@angular/core';

export interface Tile {
  cols: number;
  rows: number;
  img: string;
}

@Component({
  selector: 'app-proyecto',
  templateUrl: './proyecto.component.html',
  styleUrls: ['./proyecto.component.scss']
})
export class ProyectoComponent implements OnInit {

  constructor(
  ) {

  }

  ngOnInit(): void {

  }

}
