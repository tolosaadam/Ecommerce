import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClienteComponent } from './cliente/cliente.component';
import {HomeComponent} from './home/home.component';


const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch:'full'}, // Para llevar por defecto a la home
  {path: 'home', component: HomeComponent},
  {path: 'cliente', component: ClienteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
