import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListBooksComponent } from './Components/list-books/list-books.component';
import { SeeDetailsComponent } from './Components/see-details/see-details.component';
import { AddBooksComponent } from './Components/add-books/add-books.component';
import { UpdateBooksComponent } from './Components/update-books/update-books.component';

const routes: Routes = [
  { path: '', redirectTo: '/listBooks', pathMatch: 'full' }, // Redireccionar a 'inicio' al cargar la página
  { path: 'listBooks', component: ListBooksComponent }, // Ruta '/inicio' cargará el componente 'InicioComponent'
  { path: 'details/:id', component: SeeDetailsComponent }, // Ruta '/detalle/1' cargará el componente 'DetalleComponent' con el parámetro 'id'
  { path: 'addBooks', component: AddBooksComponent},
  { path: 'updateBooks/:id', component: UpdateBooksComponent },
  { path: '**', component: ListBooksComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
