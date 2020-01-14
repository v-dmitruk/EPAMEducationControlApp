import { Teacher } from './teacher.model';
import { Course } from './course.model';
import { Question } from './question.model';

export class Test {
    TestID : number;
    Creator : Teacher;
    Name : string;
    Description : string;
    CreationDate : Date;
    MaxMark : number;
    Duration : number;
    Courses : Course[];
    Questions : Question[];
    Date : Date;
}
