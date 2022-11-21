import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { ProjectService } from 'src/app/_services/project/project.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-table-project',
  templateUrl: './table-project.component.html',
  styleUrls: ['./table-project.component.scss']
})
export class TableProjectComponent implements OnInit {

  ELEMENT_DATA: any[] = [];

  displayedColumns: string[] = [
    'nombre',
    'padres'
  ];
  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  isSearch: boolean = false;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(
    private fb: FormBuilder,
    private projectSvc: ProjectService,
  ) {
  }

  ngOnInit(): void {

    this.projectSvc.getProjects().subscribe(res => {
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
