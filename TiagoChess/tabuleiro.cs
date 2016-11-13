using System;

namespace TiagoChess
{
	public class tabuleiro
	{
		public peca[,] posicao;

		public tabuleiro ()
		{
			this.posicao = new peca[8, 8];

			for (int l = 0; l < posicao.GetLength (1); l++) { 
				for (int c = 0; c < posicao.GetLength (0); c++) {
					posicao [l, c] = new empty ();
					//o
				


				}

				//primeira linha pretas
				posicao [0, 0] = new torre ('P');
				posicao [0, 7] = new torre ('P');
				posicao [0, 1] = new cavalo ('P');
				posicao [0, 6] = new cavalo ('P');
				posicao [0, 2] = new bispo ('P');
				posicao [0, 5] = new bispo ('P');
				posicao [0, 3] = new rainha ('P');
				posicao [0, 4] = new rei ('P');

				//primeira linha brancas
				posicao [7, 0] = new torre ('B');
				posicao [7, 7] = new torre ('B');
				posicao [7, 1] = new cavalo ('B');
				posicao [7, 6] = new cavalo ('B');
				posicao [7, 2] = new bispo ('B');
				posicao [7, 5] = new bispo ('B');
				posicao [7, 3] = new rainha ('B');
				posicao [7, 4] = new rei ('B');

				//peoes pretos
				for (int i = 0; i < posicao.GetLength (0); i++) {
					posicao [1, i] = new peao ('P');
				}
				//peoes brancos
				for (int i = 0; i < posicao.GetLength (0); i++) {
					posicao [6, i] = new peao ('B');
				}

		}
	}
		public bool checkpecaini(string jogada,	char cor){
			int[] posini = this.descodifica_pos (jogada);
			if (posini [0] == -1 || posini [1] == -1) {
				return false;
			}
			if (this.posicao [posini [0], posini [1]].cor != cor) {
				return false;
			}
			return true;
		}

		public bool checkpos (string pos){
			int[] destino = this.descodifica_pos (pos);
			if (destino [0] == -1 || destino [1] == -1) {
				return false;
			}
			return true;
		}


		public bool checkdestino(int[] destino,peca pecamov,object des,int[] posini){
			if (des.GetType ().ToString().Split('.')[1] != "empty"){
				peca pecades = (peca)des;
				if (pecades.cor == pecamov.cor) {
					return false;
					}}

		

			;

			foreach (int[] jog in pecamov.jogadas (this.posicao,posini)){
				if (jog[0]==destino[0] && jog[1]==destino[1]){
					return true;
				}
			}


			return false;
		}

		public int[] descodifica_pos(string posicao){
			char[] pos = posicao.ToUpper().ToCharArray();
			int[] index = new int [2];
			if (pos.Length != 2) {
				index [0] = index [1] = -1;
				return index;
			}
			switch (pos[0])
			{
			case 'A':
				index [1] = 0;
				break;
			case 'B':
				index [1] = 1;
				break;
			case 'C':
				index [1] = 2;
				break;
			case 'D':
				index [1] = 3;
				break;
			case 'E':
				index [1] = 4;
				break;
			case 'F':
				index [1] = 5;
				break;
			case 'G':
				index [1] = 6;
				break;
			case 'H':
				index [1] = 7;
				break;
			default:
				index [1] = -1;
				break;
			}

			switch (pos[1])
			{
			case '1':
				index [0] = 0;
				break;
			case '2':
				index [0] = 1;
				break;
			case '3':
				index [0] = 2;
				break;
			case '4':
				index [0] = 3;
				break;
			case '5':
				index [0] = 4;
				break;
			case '6':
				index [0] = 5;
				break;
			case '7':
				index [0] = 6;
				break;
			case '8':
				index [0] = 7;
				break;
			default:
				index [1] = -1;
				break;
			}

			return index;
		}
}
}

