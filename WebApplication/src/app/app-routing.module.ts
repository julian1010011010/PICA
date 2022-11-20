import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SkeletonComponent } from './layout/skeleton/skeleton.component';
import { HomeComponent } from './_pages/home/home.component';
import { TableProjectComponent } from './_pages/table-project/table-project.component';
import { CreateProjectComponent } from './_pages/create-project/create-project.component';


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
        path: 'search',
        component: TableProjectComponent
      },
      {
        path: 'crear-proyecto',
        component: CreateProjectComponent
      }
    ]
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
