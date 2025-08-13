import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { JugueteService } from '../../services/juguete.service';
import { Juguete } from '../../models/juguete';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-editar-juguete',
  imports: [CommonModule, FormsModule],
  templateUrl: './editar-juguete.html',
  styleUrl: './editar-juguete.css'
})
export class EditarJuguete implements OnInit {
  @Input() juguete?: Juguete;
  @Output() juguetesUpdated = new EventEmitter<Juguete[]>();

  constructor(private jugueteService: JugueteService) {}

  ngOnInit(): void {}

  updateJuguete(juguete: Juguete) {
    this.jugueteService
      .updateJuguete(juguete)
      .subscribe((juguetes: Juguete[]) => this.juguetesUpdated.emit(juguetes));
      alert('Producto actualizado correctamente');
  }

  deleteJuguete(juguete: Juguete) {
    if (confirm('¿Seguro que deseas eliminar este registro?')) {
    this.jugueteService
      .deleteJuguete(juguete)
      .subscribe((juguetes: Juguete[]) => this.juguetesUpdated.emit(juguetes));
    console.log('Eliminando', juguete.nombre);
  }
    
  }

  createJuguete(juguete: Juguete) {
    this.jugueteService
      .createJuguete(juguete)
      .subscribe((juguetes: Juguete[]) => this.juguetesUpdated.emit(juguetes));
      alert('Producto guardado correctamente');
  }
}