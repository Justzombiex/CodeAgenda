import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';
import { environment } from '../../environments/environment';
import { ResponseApi } from '../Interfaces/response-api';
import { User } from '../Interfaces/user';
import { Login } from '../Interfaces/login';

@Injectable({
  providedIn: 'root'
})
export class UserService {

private urlAPI:string = environment.endpoint + "User"

  constructor(private http:HttpClient) { }

  Login(request: Login):Observable<ResponseApi>{

    return this.http.post<ResponseApi>(`${this.urlAPI}Login`, request);
  }

  GetAll(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.urlAPI}GetAll`);
}

Create(request: User): Observable<ResponseApi>{
  return this.http.post<ResponseApi>(`${this.urlAPI}Create`, request);
}

Edit(request: User): Observable<ResponseApi>{
  return this.http.put<ResponseApi>(`${this.urlAPI}Edit`, request);
}

Delete(id: string): Observable<ResponseApi>{
  return this.http.delete<ResponseApi>(`${this.urlAPI}Delete/${id}`);
}

}