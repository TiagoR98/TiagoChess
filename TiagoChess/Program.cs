using System;

namespace TiagoChess
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.Clear ();
			tabuleiro tab1 = new tabuleiro();
			bool jogada = true;
			bool cheque = false;

			Inicio:
			Console.Clear ();
			gera_titulo ();

			char cor;
			if (jogada){
				cor = 'B';
			}else{
				cor = 'P';
			}


			Console.WriteLine ("     A   B   C   D   E   F   G   H");
			for (int l = 0; l < tab1.posicao.GetLength (1); l++) { 
				if (l == 0) {
					Console.Write ("   ");
					Console.Write ('\u250c');
					int c = -1;
					for (int i=0;i<24;i++){
						c++;
						if (c == 3) {
							Console.Write ('\u252c');
							c = 0;
						}
						Console.Write ('\u2500');
					}
				} else {
					Console.Write ("   ");
					Console.Write ('\u251c');
					int c = -1;
					for (int i=0;i<24;i++){
						c++;
						if (c == 3) {
							Console.Write ('\u253c');
							c = 0;
						}
						Console.Write ('\u2500');
					}
				}

				if (l == 0) {
					Console.WriteLine ('\u2510');
				} else {
					Console.WriteLine ('\u2524');
				}
				Console.Write (" "+(l+1).ToString()+" ");
				Console.Write ('\u2502');
				for (int c = 0; c < tab1.posicao.GetLength (0); c++) {
					Console.Write (" ");
					Console.Write (tab1.posicao [l, c].simbolo+" ");
					Console.Write ('\u2502');
					}
				Console.WriteLine ();
				if (l == tab1.posicao.GetLength (1)-1) {
					Console.Write ("   ");
					Console.Write ('\u2514');
					int c = -1;
					for (int i=0;i<24;i++){
						c++;
						if (c == 3) {
							Console.Write ('\u2534');
							c = 0;
						}
						Console.Write ('\u2500');
					}
					Console.Write ('\u2518');
				}

			}
			Console.WriteLine ();
			Console.WriteLine ();
			Console.WriteLine ();
			if (jogada) {
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine ("Peças Brancas: ");
				Console.ResetColor ();
			}else{
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Peças Pretas: ");	
				Console.ResetColor ();
			}
			Console.WriteLine ();
				
			Console.Write ("Peça a mover: ");
			string posini = Console.ReadLine ();
			if (!(tab1.checkpecaini (posini, cor))) {
				jog_inv ();
				goto Inicio;
			}
			Console.Write ("Destino: ");
			string destino = Console.ReadLine ();
			int[] pecamov = tab1.descodifica_pos (posini);
			int[] des = tab1.descodifica_pos (destino);
			if ((tab1.checkpos (destino))) {
 				if (!(tab1.checkdestino (des, tab1.posicao [pecamov [0], pecamov [1]], tab1.posicao [des [0], des [1]],tab1.descodifica_pos(posini)))) {
					jog_inv ();
					goto Inicio;
				}
			}else{
				jog_inv ();
				goto Inicio;
			}

			if (tab1.posicao [des [0], des [1]].GetType ().ToString ().Split ('.') [1] == "rei") {
				cheque=true;
			}
			tab1.posicao [des [0], des [1]] = tab1.posicao [pecamov [0], pecamov [1]]; 
			tab1.posicao [pecamov [0], pecamov [1]] = new empty ();
			if (!(cheque)){
				jogada = !jogada;
				goto Inicio;
			}else{
				chequemate(jogada);
			}


		}
		public static  void jog_inv (){
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Jogada Inválida");
			Console.ResetColor ();
			Console.ReadKey ();
		}

		public static void gera_titulo(){
			Console.WriteLine ("▄▄▄█████▓ ██▓ ▄▄▄        ▄████  ▒█████      ▄████▄   ██░ ██ ▓█████   ██████   ██████ ");
			Console.WriteLine ("▓  ██▒ ▓▒▓██▒▒████▄     ██▒ ▀█▒▒██▒  ██▒   ▒██▀ ▀█  ▓██░ ██▒▓█   ▀ ▒██    ▒ ▒██    ▒ ");
			Console.WriteLine ("▒ ▓██░ ▒░▒██▒▒██  ▀█▄  ▒██░▄▄▄░▒██░  ██▒   ▒▓█    ▄ ▒██▀▀██░▒███   ░ ▓██▄   ░ ▓██▄");   
				Console.WriteLine ("░ ▓██▓ ░ ░██░░██▄▄▄▄██ ░▓█  ██▓▒██   ██░   ▒▓▓▄ ▄██▒░▓█ ░██ ▒▓█  ▄   ▒   ██▒  ▒   ██▒");
					Console.WriteLine ("  ▒██▒ ░ ░██░ ▓█   ▓██▒░▒▓███▀▒░ ████▓▒░   ▒ ▓███▀ ░░▓█▒░██▓░▒████▒▒██████▒▒▒██████▒▒");
						Console.WriteLine ("▒   ░░   ░▓   ▒▒   ▓▒█░ ░▒   ▒ ░ ▒░▒░▒░    ░ ░▒ ▒  ░ ▒ ░░▒░▒░░ ▒░ ░▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░");
							Console.WriteLine ("    ░     ▒ ░  ▒   ▒▒ ░  ░   ░   ░ ▒ ▒░      ░  ▒    ▒ ░▒░ ░ ░ ░  ░░ ░▒  ░ ░░ ░▒  ░ ░");
								Console.WriteLine ("  ░       ▒ ░  ░   ▒   ░ ░   ░ ░ ░ ░ ▒     ░         ░  ░░ ░   ░   ░  ░  ░  ░  ░  ░  ");
									Console.WriteLine ("          ░        ░  ░      ░     ░ ░     ░ ░       ░  ░  ░   ░  ░      ░        ░  ");
			Console.WriteLine ("                                           ░");                                         

		}

		public static void chequemate(bool jogada){
			Console.Clear ();

			Console.WriteLine("                                  .''.  ");     
			Console.WriteLine(@"      .''.      .        *''*    :_\/_:     . ");
			Console.WriteLine(@"     :_\/_:   _\(/_  .:.*_\/_*   : /\ :  .'.:.'.");
			Console.WriteLine(@" .''.: /\ :   ./)\   ':'* /\ * :  '..'.  -=:o:=-");
			Console.WriteLine(@":_\/_:'.:::.    ' *''*    * '.'/.' _\(/_'.':'.'");
			Console.WriteLine(@": /\ : :::::     *_\/_*     -= o =-  /)\    '  *");
			Console.WriteLine(@" '..'  ':::'     * /\ *     .'/.'.   '");
			Console.WriteLine("     *            *..*         :");
			Console.WriteLine("       *");
			Console.WriteLine("       *");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Parabéns!!!!!!!!");
			Console.WriteLine();
			Console.Write("O jogador das peças ");
			if (jogada){
				Console.Write("brancas");
			}else{
				Console.Write("pretas");
			}
				Console.WriteLine(" ganhou!!!!!!!!!!");

		}
	}
}
