import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-contaspagas',
  templateUrl: './contaspagas.component.html',
  styleUrls: ['./contaspagas.component.css']
})

export class ContaspagasComponent implements OnInit {

  constructor(private service:SharedService) { }

  ContasPagasList:any=[];

  ModalTitle:string;
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ContasPagasIdFilter:string="";
  ContasPagasNameFilter:string="";
  ContasPagasListWithoutFilter:any=[];

    ngOnInit(): void {
    this.refreshDepList();
  }

  refreshDepList(){
    this.service.getContasPagas().subscribe(data=>{
      this.ContasPagasList=data;
      this.ContasPagasListWithoutFilter=data;
    });
  }

}
