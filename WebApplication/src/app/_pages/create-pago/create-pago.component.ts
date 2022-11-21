import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { ProjectService } from 'src/app/_services/project/project.service';
import { ActivatedRoute } from '@angular/router';
import { PagoService } from 'src/app/_services/pago/pago.service';

@Component({
  selector: 'app-create-pago',
  templateUrl: './create-pago.component.html',
  styleUrls: ['./create-pago.component.scss']
})
export class CreatePagoComponent implements OnInit {

  pagoId: number = 0;
  esEdicion: boolean = false;
  pago: FormGroup = this.fb.group({
    idPago: [null],
    nombre: [null, Validators.required],
    idProyecto: [null, Validators.required],
    valor: [null, Validators.required],
    fechaPago: [null, Validators.required],
    pagador: [null, Validators.required]
  });
  proyectoSelected: any = null;
  teams: any[] = [
    { idProyecto:1, name: 'Proyecto 1' },
    { idProyecto:2, name: 'Proyecto 2' },
    { idProyecto:3, name: 'Proyecto 3' },
    { idProyecto:4, name: 'Proyecto 4' },
    { idProyecto:5, name: 'Proyecto 5' },
    { idProyecto:6, name: 'Proyecto 6' },
    { idProyecto:7, name: 'Proyecto 7' },
];

  constructor(
    private fb: FormBuilder,
    private pagoSvc: PagoService,
    private activatedRoute: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.pagoId = Number(this.activatedRoute.snapshot.params.id);
    this.buildForm();
  }


  buildForm(){
    if(this.pagoId > 0){
      this.esEdicion = true;
      this.pagoSvc.getPagoById(
        this.pagoId
      ).subscribe(response => {
        if(response != null){
          this.pago.patchValue(response);
          this.proyectoSelected = this.teams.find(r => r.idProyecto == this.pago.get( 'idProyecto' ).value);
          console.log(this.proyectoSelected);
        }
      });
    }
  }

  onSubmit(){
    if ( this.pago.invalid ) {
        return;
    }
    const pPago = {
      idPago: this.pago.get( 'idPago' ).value != null ? this.pago.get( 'idPago' ).value : 0 ,
      nombre:  this.pago.get( 'nombre' ).value,
      idProyecto:  this.pago.get( 'idProyecto' ).value,
      valor:  this.pago.get( 'valor' ).value,
      fechaPago:  this.pago.get( 'fechaPago' ).value,
      pagador:  this.pago.get( 'pagador' ).value
    };

    this.pagoSvc.createPago( pPago )
        .subscribe(
            response => {
              console.log(response);
              return;
            },
            err =>  console.log(err)
        )
    }

  }

