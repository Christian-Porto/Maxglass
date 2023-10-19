export class FreteListarRequest {
    regiao: string;
    
    constructor(params: Partial<FreteListarRequest>) {
        this.regiao = params.regiao || null;
    }
}
