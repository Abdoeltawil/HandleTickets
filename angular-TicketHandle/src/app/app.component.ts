import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TicketServiceService } from './TicketService.service';
import { Ticket } from '../Models/Ticket';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular-TicketHandle';
  tickets: Ticket[];

  constructor(private ticketService: TicketServiceService){
  }

  ngOnInit(): void {
   this.ticketService.getTickets().subscribe(data=>{
      this.tickets = data;
      this.tickets.forEach(t=> t.color = this.updateTicketColor(t.time));
    });
  }

  updateTicketColor(time:string):string {
    const ticketDate = new Date("0000-00-00T"+time);
    const now = new Date();
    const timeDifferenceInMinutes = Math.floor((now.getTime() - ticketDate.getTime()) / (1000 * 60));
    debugger;
    if (timeDifferenceInMinutes >= 60) {
        return "Red";
    } else if (timeDifferenceInMinutes >= 45) {
        return "Blue";
    } else if (timeDifferenceInMinutes >= 30) {
        return "Green";
    } else if (timeDifferenceInMinutes >= 15) {
        return "Yellow";
    }
    else{
      return "Gray"
    }
  }

}
