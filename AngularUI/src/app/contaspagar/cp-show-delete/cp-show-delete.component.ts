import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service';


@Component({
  selector: 'app-cp-show-delete',
  templateUrl: './cp-show-delete.component.html',
  styleUrls: ['./cp-show-delete.component.css']
})
export class CpShowDeleteComponent implements OnInit {

  constructor(private service:SharedService) { }

  ContasPagarList:any=[];

  ModalTitle:string;
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ContasPagarIdFilter:string="";
  ContasPagarNameFilter:string="";
  ContasPagarListWithoutFilter:any=[];

    ngOnInit(): void {
    this.refreshDepList();
  }

  addClick(){
    this.dep={
      id:0,
      nome:""
    }
    this.ModalTitle="Add ContasPagar";
    this.ActivateAddEditDepComp=true;
    window.location.href = './contaspagar/create';        

  }

  editClick(item){
    window.location.href = './contaspagar/edit/' + item.id;
  }
 
  paymentClick(item){
    window.location.href = './contaspagar/payment/' + item.id;
  }

  deleteClick(item){
    if(confirm('ConfirmaExclusão??')){
      this.service.deleteContasemAberto(item.id).subscribe(data=>{
        this.refreshDepList();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshDepList();
  }


  refreshDepList(){
    this.service.getContasemAberto().subscribe(data=>{
      this.ContasPagarList=data;
      this.ContasPagarListWithoutFilter=data;
    });
  }

  FilterFn(){
    var ContasPagarIdFilter = this.ContasPagarIdFilter;
    var ContasPagarNameFilter = this.ContasPagarNameFilter;

    this.ContasPagarList = this.ContasPagarListWithoutFilter.filter(function (el){
        return el.ContasPagarId.toString().toLowerCase().includes(
          ContasPagarIdFilter.toString().trim().toLowerCase()
        )&&
        el.ContasPagarName.toString().toLowerCase().includes(
          ContasPagarNameFilter.toString().trim().toLowerCase()
        )
    });
  }

  sortResult(prop,asc){
    this.ContasPagarList = this.ContasPagarListWithoutFilter.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }
}
