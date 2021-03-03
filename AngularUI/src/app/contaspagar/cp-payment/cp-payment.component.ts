import { Component, OnInit,Input } from '@angular/core';
import { cpuUsage } from 'process';
import {SharedService} from 'src/app/shared.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-cp-payment',
  templateUrl: './cp-payment.component.html',
  styleUrls: ['./cp-payment.component.css']
})
export class CpPaymentComponent implements OnInit {

  constructor(private service:SharedService, private route: ActivatedRoute ,private router: Router) { }

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
    
    if(id != null)
    {
      this.cabecalho = "Editar"

      this.service.getvaloratual(id).subscribe(data=>{
        this.model=data});
   
    }

    this.refreshDepList();

  }


  
  addContaPagar(){


    if (this.model.id != 0)
    {
       var resp = this.service.updatePagarConta(this.model).then(x=> window.location.href = './contaspagas');

       }

  

    }




  refreshDepList(){
    this.service.getFornecedores().subscribe(data=>{
      this.ContasPagasList=data});


    }
    
}
