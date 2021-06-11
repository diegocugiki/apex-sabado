import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from '../Models/Aluno';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public tituloAlunos = 'Alunos';
  public alunoSelecionado: Aluno = new Aluno();
  public modalRef: BsModalRef = new BsModalRef();

  public alunoForm = new FormGroup({
    id: new FormControl(''),
    nome: new FormControl(''),
    sobrenome: new FormControl(''),
    telefone: new FormControl('')       
  });

  public alunos = [
    { id: 1, nome:'Vinicius', sobrenome: 'Guimarães', telefone: 111111111},
    { id: 2, nome:'Eduardo', sobrenome: 'Nãosei1', telefone: 222222222},
    { id: 3, nome:'Caue', sobrenome: 'Nãosei2', telefone: 333333333},
    { id: 4, nome:'Alexandre', sobrenome: 'Nãosei3', telefone: 444444444},
    { id: 5, nome:'Marcelo', sobrenome: 'Nãosei4', telefone: 555555555}
  ];



  constructor(private fb: FormBuilder,
              private modalService: BsModalService  
  ) {
    this.criarForm();
  }

  ngOnInit(): void {
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  criarForm() {
    this.alunoForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      sobrenome: ['', Validators.required],
      telefone: ['', Validators.required]
    });
  }

  selecionarAluno(aluno: Aluno) {
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }
  voltar() {
      this.alunoSelecionado = new Aluno();
  }

  alunoSubmit() {
    console.log(this.alunoForm.value);    
  }
  

}
