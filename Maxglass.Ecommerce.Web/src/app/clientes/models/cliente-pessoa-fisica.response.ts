export class ClientePessoaFisicaResponse {
  email: string;
  cep: string;
  nome: string;
  sobreNome: string;
  cpf: string;
  telefone: string;

  constructor(params: Partial<ClientePessoaFisicaResponse>) {
    this.email = params.email || null;
    this.cep = params.cep || null;
    this.nome = params.nome || null;
    this.sobreNome = params.sobreNome || null;
    this.cpf = params.cpf || null;
    this.telefone = params.telefone || null;

  }
}
