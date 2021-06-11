import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './alunos/alunos.component';
import { PerfilComponent } from './perfil/perfil.component';
import { PrincipalComponent } from './principal/principal.component';
import { ProfessoresComponent } from './professores/professores.component';

const routes: Routes = [
  {path: '', redirectTo: 'principal', pathMatch: 'full' }, 
  {path: 'alunos', component: AlunosComponent },
  {path: 'professores', component: ProfessoresComponent },
  {path: 'perfil', component: PerfilComponent },
  {path: 'principal', component: PrincipalComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
