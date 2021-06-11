import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Professor } from '../Models/Professor';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  public tituloProfessores = 'Professores';
  public professorSelecionado: Professor = new Professor();

  public professores = [
    { id: 1, nome:'Diego', disciplina: 'C#'},
    { id: 2, nome:'Professor2', disciplina: 'Java'},
    { id: 3, nome:'Professor3', disciplina: 'Python'}

  ];

  public professorForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    disciplina: new FormControl(''),
  });

  constructor(private fb: FormBuilder) {
    this.criarForm();
  }

  ngOnInit() {
  }

  criarForm() {
    this.professorForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      disciplina: ['', Validators.required],
    });
  }

  selecionarProfessor(professor: Professor) {
    this.professorSelecionado = professor;
    this.professorForm.patchValue(professor);
  }
  
  voltar() {
      this.professorSelecionado = new Professor();
  }

  professorSubmit() {
    console.log(this.professorForm.value);    
  }

}
