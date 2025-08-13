import { Injectable } from '@angular/core';
import { Juguete } from '../models/juguete';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { enviroment } from '../../enviroments/enviroment';


@Injectable({
  providedIn: 'root'
})
export class JugueteService 
{
  private url = "Juguete";

  constructor(private http: HttpClient){}
  
  public getJuguetes() : Observable<Juguete[]> {

    return this.http.get<Juguete[]>(`${enviroment.apiUrl}/${this.url}`);

  }
  
  public updateJuguete(juguete: Juguete): Observable<Juguete[]> {
    return this.http.put<Juguete[]>(
      `${enviroment.apiUrl}/${this.url}`,
      juguete
    );
  }

  public createJuguete(juguete: Juguete): Observable<Juguete[]> {
    return this.http.post<Juguete[]>(
      `${enviroment.apiUrl}/${this.url}`,
      juguete
    );
  }

  public deleteJuguete(juguete: Juguete): Observable<Juguete[]> {
    return this.http.delete<Juguete[]>(
      `${enviroment.apiUrl}/${this.url}/${juguete.id}`
    );
  }
}