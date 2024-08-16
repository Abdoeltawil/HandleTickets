import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Ticket } from '../Models/Ticket';
import { HttpClientModule } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TicketServiceService {

baseUrl: string = 'http://localhost:5279/api/v1/Ticket';

constructor(private http: HttpClient) { }
 
getTickets(){
  return this.http.get<Ticket[]>(this.baseUrl+'/GetTickets?PageSize=5&PageIndex=0');
}
}
