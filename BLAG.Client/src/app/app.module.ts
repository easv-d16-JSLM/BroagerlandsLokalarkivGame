import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TextComponent } from './question/text/text.component';
import { AnnouncementComponent } from './question/announcement/announcement.component';
import { ImageComponent } from './question/image/image.component';
import { VideoComponent } from './question/video/video.component';
import { AudioComponent } from './question/audio/audio.component';

@NgModule({
  declarations: [
    AppComponent,
    TextComponent,
    AnnouncementComponent,
    ImageComponent,
    VideoComponent,
    AudioComponent
  ],
  imports: [
    BrowserModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', redirectTo: 'home', pathMatch: 'full'},
      {path: 'announcement', component: AnnouncementComponent},
      {path: 'audio', component: AudioComponent},
      {path: 'image', component: ImageComponent},
      {path: 'text', component: TextComponent},
      {path: 'video', component: VideoComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
