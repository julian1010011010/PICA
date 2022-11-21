import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  isExpanded: boolean = false;
  esProyecto: boolean = false;
  esPago: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  manageState(state: number){
    this.isExpanded = true;
    if(state == 1){
      this.esProyecto = !this.esProyecto;
      this.esPago = false;
    }else if(state == 2){
      this.esPago = !this.esPago;
      this.esProyecto = false;
    }else{
      this.esProyecto = false;
      this.esPago = false;
    }
  }
}
