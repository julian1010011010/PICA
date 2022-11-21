import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkeletonComponent } from './layout/skeleton/skeleton.component';
import { HomeComponent } from './_pages/home/home.component';
import { TableProjectComponent } from './_pages/table-project/table-project.component';
import { CreateProjectComponent } from './_pages/create-project/create-project.component';
import { ProyectoComponent } from './_pages/proyecto/proyecto.component';
import { TablePagoComponent } from './_pages/table-pago/table-pago.component';
import { CreatePagoComponent } from './_pages/create-pago/create-pago.component';
import { PagoComponent } from './_pages/pago/pago.component';


const routes: Routes = [
  {
    path: '',
    component: SkeletonComponent,
    children: [
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'proyectos',
        component: ProyectoComponent
      },
      {
        path: 'crear-proyecto',
        component: CreateProjectComponent
      },
      {
        path: 'editar-proyecto/:id',
        component: CreateProjectComponent
      },
      {
        path: 'administrar-proyectos',
        component: TableProjectComponent
      },
      {
        path: 'pagos',
        component: PagoComponent
      },
      {
        path: 'crear-pago',
        component: CreatePagoComponent
      },
      {
        path: 'editar-pago/:id',
        component: CreatePagoComponent
      },
      {
        path: 'administrar-pagos',
        component: TablePagoComponent
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
