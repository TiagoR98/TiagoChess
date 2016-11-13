﻿using System;
using System.Collections.Generic;

namespace TiagoChess
{		
	public class peca
	{
		public char cor { get; }
		public virtual char simbolo { get; }

		public virtual int[][] jogadas(peca[,] tabuleiro, int[] posicao){ return null;}

		public void jogada (string destino,string[,] tabuleiro)
		{

		}

		public peca()
		{
		}
			

		public peca (char cor)
		{
			this.cor = cor;
		}
	}

	public class peao : peca
	{
		private char sim = '\u2610';
		public peao(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2659';
				break;
			case 'B':
				this.sim='\u265D';
				break;
			}
		}
		public override char simbolo {get{return sim;}}

		public override int[][] jogadas (peca[,] tabuleiro, int[] posicao){
			List<int[]> listjogadas= new List<int[]>();
			if (this.cor.Equals('P')) {
				if (posicao [0] == 1) {
					for (int i = 1; i < 3; i++) {
						int temp = posicao [0]+i;
						if (temp < 0)
							continue;
						if (tabuleiro [temp, posicao [1]].GetType ().ToString ().Split ('.') [1] == "empty") {
							int[] curpos = new int[2] {temp,posicao[1]};
							listjogadas.Add (curpos);
						}
					}
				} else {
					for (int i = -1; i < 2; i += 2) {
						int[] temp2 = new int[2]{posicao [0]+1,posicao [1]+i};
						bool invalido =false;
						foreach (int val in temp2){
							if (val < 0 || val>7) {
								invalido=true;
							}
						}
						if (invalido)
							continue;
						if (tabuleiro [temp2[0], temp2[1]].GetType ().ToString ().Split ('.') [1] != "empty" && tabuleiro [posicao [0] + 1, posicao [1] + i].cor != this.cor) {
							listjogadas.Add (temp2);
						}
					}
					int[] temp3 =new int[2]{posicao [0]+1, posicao [1]};
					bool invalido2 =false;
					foreach (int val in temp3){
						if (val < 0 || val>7) {
							invalido2=true;
						}
					}
					if (!(invalido2))
						if (tabuleiro [temp3[0], temp3[1]].GetType ().ToString ().Split ('.') [1] == "empty") {
							listjogadas.Add (temp3);
						}
				}
			} else {
				if (posicao [0]+2 == tabuleiro.GetLength(0)) {
					for (int i = 1; i < 3; i++) {
						int temp = posicao [0]-i;
						if (temp < 0)
							continue;
						if (tabuleiro [temp, posicao [1]].GetType ().ToString ().Split ('.') [1] == "empty") {
							int[] curpos = new int[2] {temp,posicao[1]};
							listjogadas.Add (curpos);
						}
					}
				} else {
					for (int i = -1; i < 2; i += 2) {
						int[] temp2 = new int[2]{posicao [0]-1,posicao [1]+i};
						bool invalido =false;
						foreach (int val in temp2){
							if (val < 0 || val>7) {
								invalido=true;
							}
						}
						if (invalido)
							continue;
						if (tabuleiro [temp2[0], temp2[1]].GetType ().ToString ().Split ('.') [1] != "empty" && tabuleiro [posicao [0] + 1, posicao [1]+i].cor!=this.cor) {
							listjogadas.Add (temp2);
						}

						}
					int[] temp3 = new int[2]{ posicao [0]-1, posicao [1] };
					bool invalido2 =false;
					foreach (int val in temp3){
						if (val < 0 || val>7) {
							invalido2=true;
						}
					}
					if (!(invalido2))
						if (tabuleiro [temp3[0], temp3[1]].GetType ().ToString ().Split ('.') [1] == "empty") {
							listjogadas.Add (temp3);
					}
				}
			}
					return listjogadas.ToArray();
				
		}
	}

	public class rei : peca
	{
		private char sim = '\u2610';
		public rei(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2654';
				break;
			case 'B':
				this.sim='\u265A';
				break;
			}
		}
		public override char simbolo {get{return sim;}}
	}

	public class rainha : peca
	{
		private char sim = '\u2610';
		public rainha(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2655';
				break;
			case 'B':
				this.sim='\u265B';
				break;
			}
		}
		public override char simbolo {get{return sim;}}
	}

	public class torre : peca
	{
		private char sim = '\u2610';
		public torre(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2656';
				break;
			case 'B':
				this.sim='\u265C';
				break;
			}
		}
		public override char simbolo {get{return sim;}}
	}

	public class bispo : peca
	{
		private char sim = '\u2610';
		public bispo(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2657';
				break;
			case 'B':
				this.sim='\u265D';
				break;
			}
		}
		public override char simbolo {get{return sim;}}
	}

	public class cavalo : peca
	{
		private char sim = '\u2610';
		public cavalo(char cor) : base(cor)
		{
			switch (cor)
			{
			case 'P':
				this.sim='\u2658';
				break;
			case 'B':
				this.sim='\u265E';
				break;
			}
		}
		public override char simbolo {get{return sim;}}
	}

	public class empty : peca
	{
		public override char simbolo {get{return '\u0020';}}
		public empty()
		{
		}
	}

		
}

