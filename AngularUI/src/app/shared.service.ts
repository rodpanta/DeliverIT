import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
import {formatDate} from '@angular/common';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic ' + btoa('name:password'),
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44389/api";


  constructor(private http:HttpClient) { }

   getContasemAberto():Observable<any[]>{
     return this.http.get<any>(this.APIUrl + '/contaspagar/GetContasemAberto',httpOptions);
   }

   getContasPagas():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/contaspagar/GetContasPagas',httpOptions);
  }

  getFornecedores():Observable<any[]>{
    return this.http.get<any>(this.APIUrl + '/fornecedor',httpOptions);
  }

  getConta(val:any){
    return this.http.get<any>(this.APIUrl+'/contaspagar/'+val, httpOptions );
  }

  getvaloratual(val:any){
    return this.http.get<any>(this.APIUrl+'/contaspagar/valoratual/'+val, httpOptions );
  }

   deleteContasemAberto(val:any){
    return this.http.delete(this.APIUrl+'/contaspagar/'+val, httpOptions );
  }

  async addContaPagar(val:any){

  
    var datavencimento = val.dataVencimento.toString().replaceAll('/','-');;
    var idfornec = val.idfornecedor;
    var valor =  val.valorOriginal.toString().replaceAll(',','.');

    return await  this.http.post(this.APIUrl+'/contaspagar' ,
    {
      "nome":  val.nome ,
      "valorOriginal": valor,
      "dataVencimento": datavencimento,
      "idfornecedor": 1 
    }, httpOptions)
    .toPromise();

  }


  async updatePagarConta(val:any){


    var datavencimento = val.dataVencimento.toString().replaceAll('/','-');
    var idfornec = val.idfornecedor;
    var valor =  val.valorOriginal.toString().replaceAll(',','.');
    var id = val.id;
    var nome = val.nome;

    return await this.http.put(this.APIUrl+'/contaspagar/' + id,
    {
      "id" : id,
      "nome":  nome ,
      "valorOriginal": valor,
      "dataVencimento": datavencimento,
      "idfornecedor": idfornec,
      "datapagamento": val.dataPagamento.toString().replaceAll('/','-'),
      "diasEmAtraso": val.diasEmAtraso,
      "valorCorrigido": val.valorCorrigido, 
    }, httpOptions).toPromise();

  }

  async updateContaPagar(val:any){


    var datavencimento = val.dataVencimento.toString().replaceAll('/','-');
    var idfornec = val.idfornecedor;
    var valor =  val.valorOriginal.toString().replaceAll(',','.');
    var id = val.id;
    var nome = val.nome;

    return await this.http.put(this.APIUrl+'/contaspagar/' + id,
    {
      "id" : id,
      "nome":  nome ,
      "valorOriginal": valor,
      "dataVencimento": datavencimento,
      "idfornecedor": idfornec,
    }, httpOptions)
    .toPromise();

  }

}



