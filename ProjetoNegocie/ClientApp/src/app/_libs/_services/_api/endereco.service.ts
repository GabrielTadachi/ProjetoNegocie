import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { EnderecoModel } from "../../_models/endereco.model";

@Injectable({
  providedIn: 'root'
})
export class EnderecoService {

  constructor(private http: HttpClient) { }

  getEnderecoFromDB(cep: string): Observable<EnderecoModel> {
    const url = environment.apiUrl + "/api/endereco/getDB" + cep;
    return this.http.get<EnderecoModel>(url);
  }

  getEnderecoFromAPI(cep: string): Observable<EnderecoModel> {
    const url = environment.apiUrl + "/api/endereco/getAPI" + cep;
    return this.http.get<EnderecoModel>(url);
  }

  post(endereco: EnderecoModel) {
    const url = environment.apiUrl + "/api/endereco/";
    return this.http.post<EnderecoModel>(url, endereco);
  }
}
