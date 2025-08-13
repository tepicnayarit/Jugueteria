import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Juguete } from './models/juguete';
import { JugueteService } from './services/juguete.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EditarJuguete } from "./components/editar-juguete/editar-juguete";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule, FormsModule, EditarJuguete],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Juguete.UI');
  juguetes: Juguete[] = [];
  jugueteToEdit?: Juguete;

  constructor(private jugueteService : JugueteService){}

  ngOnInit() : void{
    this.jugueteService
    .getJuguetes()
    .subscribe((result: Juguete[]) => (this.juguetes = result));
    console.log(this.juguetes);
  }

  updateJugueteList(juguetes : Juguete[]){
    this.juguetes = juguetes;
  }

  initNewJuguete(){
    this.jugueteToEdit = new Juguete();
  }

  editJuguete(juguete : Juguete){
    this.jugueteToEdit = juguete;
  }
}
