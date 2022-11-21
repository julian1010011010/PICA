import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { ProjectService } from 'src/app/_services/project/project.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { PagoService } from 'src/app/_services/pago/pago.service';

@Component({
  selector: 'app-table-pago',
  templateUrl: './table-pago.component.html',
  styleUrls: ['./table-pago.component.scss']
})
export class TablePagoComponent implements OnInit {
  ELEMENT_DATA: any[] = [];

  displayedColumns: string[] = [
    'nombre',
    'idProyecto',
    'valor',
    'fechaPago',
    'pagador',
    'idPago'
  ];

  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  isSearch: boolean = false;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fb: FormBuilder,
    private pagoSvc: PagoService,
  ) {
  }

  ngOnInit(): void {

    this.pagoSvc.getListPagos().subscribe(res => {
      if(res != null){
        this.dataSource = new MatTableDataSource( res );
        this.inicializarTabla();
      }
    });

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  inicializarTabla() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
}
