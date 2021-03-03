
import { Component, OnInit,Input } from '@angular/core';
import { cpuUsage } from 'process';
import {SharedService} from 'src/app/shared.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cp-add-edit',
  templateUrl: './cp-add-edit.component.html',
  styleUrls: ['./cp-add-edit.component.css']
})
export class CpAddEditComponent implements OnInit {

  constructor(private service:SharedService, private route: ActivatedRoute) { }

  @Input() dep: any;
  nome:string;
  model = { 
    'id' : 0,
    'nome' : '' ,
    'valorOriginal': "",
    'dataVencimento': "",
    "dataPagamento": "",
    "diasEmAtraso": "",
    "valorCorrigido": "",
    "idfornecedor": "" ,
    "fornecedor" : {"id" : "", "nome": ""}
  };
cabecalho: string;

  numbers = ['1','2','3'];

  ContasPagasList:any=[];

  ngOnInit(): void {

    var id = this.route.snapshot.paramMap.get('id');
    
    if(id == null)
    {
      this.cabecalho = "Novo"
    }
    else
    {
      this.cabecalho = "Editar"

      this.service.getConta(id).subscribe(data=>{
        this.model=data});
   
    }

    this.refreshDepList();

  }

  addContaPagar(){


    if (this.model.id == 0)
    {
      var resp = this.service.addContaPagar(this.model).then(x=> window.location.href = './contaspagar');;
    }
    else
    {
      var respup = this.service.updateContaPagar(this.model).then(x=> window.location.href = './contaspagar');
     }



     //window.location.href = './contaspagar';    

    }


  refreshDepList(){
    this.service.getFornecedores().subscribe(data=>{
      this.ContasPagasList=data});


    }
}