import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Collection } from '../../shared/models/Collection';
import { EventService } from '../../shared/services/EventService';
import { CollectionFormComponent } from '../collection-form/collection-form.component';

@Component({
  selector: 'collection-item',
  standalone: true,
  imports: [CommonModule, CollectionFormComponent],
  templateUrl: './collection-item.component.html',
  styleUrl: './collection-item.component.css',
})
export class CollectionItemComponent {
  @Input() collection!: Collection;
  isEditing: boolean = false;

  constructor(private events: EventService) {}

  onClickEditClose() {
    this.isEditing = !this.isEditing;
  }

  onDelete() {
    this.events.emit('deleteCollection', this.collection);
  }
}
