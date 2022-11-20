import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { map, startWith } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { ProjectService } from 'src/app/_services/project/project.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-project',
  templateUrl: './create-project.component.html',
  styleUrls: ['./create-project.component.scss']
})
export class CreateProjectComponent implements OnInit {

  proyectoId: number = 0;
  project: FormGroup = this.fb.group({
    proyectoId: [null],
    nombre: [null, Validators.required],
    presupuesto: [null, Validators.required]
  });

  constructor(
    private fb: FormBuilder,
    private projectSvc: ProjectService,
    private activatedRoute: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.proyectoId = Number(this.activatedRoute.snapshot.params.id);
    this.buildForm();
  }


  buildForm(){
    if(this.proyectoId > 0){
      this.projectSvc.getProjectById(
        this.proyectoId
      ).subscribe(response => {
        if(response != null && response.length > 0){
          this.project.patchValue(response[0]);
        }
      });
    }
  }

  onSubmit(){
    if ( this.project.invalid ) {
        return;
    }

    const pProyecto = {
      proyectoId: this.project.get( 'proyectoId' ).value != null ? this.project.get( 'proyectoId' ).value : 0 ,
      nombre:  this.project.get( 'nombre' ).value,
      presupuesto:  this.project.get( 'presupuesto' ).value
    };

    this.projectSvc.createProject( pProyecto )
        .subscribe(
            response => {
              console.log(response);
              return;
            },
            err =>  console.log(err)
        )
    }

  }

