import { User } from "src/app/core/models/user"
import { CommentDto } from "./commentDto"

export class ContentDto {
    id!: string
    title!: string
    text!: string
    comments:CommentDto[]=[]
    user!:User
}