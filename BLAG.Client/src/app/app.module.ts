import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AppComponent } from './app.component';
import { TextComponent } from './question/text/text.component';
import { AnnouncementComponent } from './question/announcement/announcement.component';
import { ImageComponent } from './question/image/image.component';
import { VideoComponent } from './question/video/video.component';
import { AudioComponent } from './question/audio/audio.component';
import { TextViewComponent } from './question/text/view/view.component';
import { ImageViewComponent } from './question/image/view/view.component';
import { VideoViewComponent } from './question/video/view/view.component';
import { AudioViewComponent } from './question/audio/view/view.component';
import { AnnouncementViewComponent } from './question/announcement/view/view.component';
import { AppRoutingModule } from './app-routing.module';
import { QuestionnaireComponent } from './questionnaire/questionnaire/questionnaire.component';
import { AnswerComponent } from './answer/answer/answer.component';
import { NavigationComponent } from './navigation/navigation.component';
import { HomeComponent } from './home/home.component';
import { ConnectComponent } from './home/connect/connect.component';
import { WaitComponent } from './home/wait/wait.component';
import { QuestionsComponent } from './settings/questions/questions.component';
import { GameFlowComponent } from './game-flow/game-flow.component';
import { MatTableModule } from '@angular/material';
import { APIService } from './Services/APIServices';
import { HttpClientModule } from '@angular/common/http'; 
import { TextDataSource } from './question/text/text.component';
import { PlayerComponent } from './player/player.component';
import { PlayeranswerComponent } from './playeranswer/playeranswer.component';



@NgModule({
  declarations: [
    AppComponent,
    TextComponent,
    AnnouncementComponent,
    ImageComponent,
    VideoComponent,
    AudioComponent,
    TextViewComponent,
    ImageViewComponent,
    VideoViewComponent,
    AudioViewComponent,
    AnnouncementViewComponent,
    NavigationComponent,
    HomeComponent,
    ConnectComponent,
    WaitComponent,
    QuestionsComponent,
    QuestionnaireComponent,
    AnswerComponent,
    GameFlowComponent,
    PlayerComponent,
    PlayeranswerComponent,    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule,
    MatTableModule,
    HttpClientModule,
    
  ],
  providers: [APIService, HttpClient, HttpModule, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
