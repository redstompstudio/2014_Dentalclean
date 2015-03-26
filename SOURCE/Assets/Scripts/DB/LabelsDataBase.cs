using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LabelsDataBase : MonoBehaviour 
{
	private static LabelsDataBase instance;
	public List<SeloInfos> selosList = new List<SeloInfos>();

	private Dictionary<TIPO_CERDA, SeloInfos> selosTipoCerdas = new Dictionary<TIPO_CERDA, SeloInfos>();
	private Dictionary<ATRIBUTOS, SeloInfos> selosAtributos = new Dictionary<ATRIBUTOS, SeloInfos>();
	private Dictionary<CABECAS, SeloInfos> selosCabecas = new Dictionary<CABECAS, SeloInfos>();
	private Dictionary<VALORIZACAO, SeloInfos> selosValorizacao = new Dictionary<VALORIZACAO, SeloInfos>();
	private Dictionary<CLASSIFICAO_ETARIA, SeloInfos> selosEtaria = new Dictionary<CLASSIFICAO_ETARIA, SeloInfos>();
	private Dictionary<OUTROS, SeloInfos> selosOutros = new Dictionary<OUTROS, SeloInfos>();
	private Dictionary<USO_PRODUTOS, SeloInfos> selosUsoProduto = new Dictionary<USO_PRODUTOS, SeloInfos>();
	private Dictionary<PUBLICO, SeloInfos> selosPublico = new Dictionary<PUBLICO, SeloInfos>();

	public static LabelsDataBase Instance
	{
		get{
			if(instance == null)
				instance = FindObjectOfType(typeof(LabelsDataBase)) as LabelsDataBase;

			return instance;
		}
	}

	public void RegisterLabel(SeloInfos pInfo)
	{
		if(!selosList.Contains(pInfo))
		{
			selosList.Add(pInfo);

			switch(pInfo.category)
			{
			case LABEL_CATEGORY.TEXTURA:
				selosTipoCerdas.Add(pInfo.textura, pInfo);
				break;

			case LABEL_CATEGORY.ATRIBUTO:
				selosAtributos.Add(pInfo.atributo, pInfo);
				break;

			case LABEL_CATEGORY.CABECA:
				selosCabecas.Add(pInfo.cabeca, pInfo);
				break;

			case LABEL_CATEGORY.VALORIZACAO:
				selosValorizacao.Add(pInfo.valorizacao, pInfo);
				break;

			case LABEL_CATEGORY.CLASSIFICACAO_ETARIA:
				selosEtaria.Add(pInfo.classificacaoEtaria, pInfo);
				break;

			case LABEL_CATEGORY.OUTROS:
				selosOutros.Add(pInfo.outros, pInfo);
				break;

			case LABEL_CATEGORY.USO_PRODUTOS:
				selosUsoProduto.Add(pInfo.usoProdutos, pInfo);
				break;

			case LABEL_CATEGORY.PUBLICO:
				selosPublico.Add(pInfo.publico, pInfo);
				break;
			}
		}
	}

	public void EnableSelos(ItemSettings pItem)
	{
		DisableAll();

		if(pItem.texturas != null && pItem.texturas.Length > 0)
		{
			for(int i = 0; i < pItem.texturas.Length; i++)
				selosTipoCerdas[pItem.texturas[i]].Enable();
		}

		if(pItem.atributos != null && pItem.atributos.Length > 0)
		{
			for(int i = 0; i < pItem.atributos.Length; i++)
				selosAtributos[pItem.atributos[i]].Enable();
		}

		if(pItem.cabecas != null && pItem.cabecas.Length > 0)
		{
			for(int i = 0; i < pItem.cabecas.Length; i++)
				selosCabecas[pItem.cabecas[i]].Enable();
		}

		if(pItem.valorizacao != null && pItem.valorizacao.Length > 0)
		{
			for(int i = 0; i < pItem.valorizacao.Length; i++)
				selosValorizacao[pItem.valorizacao[i]].Enable();
		}

		if(pItem.classificaoEtaria != null && pItem.classificaoEtaria.Length > 0)
		{
			for(int i = 0; i < pItem.classificaoEtaria.Length; i++)
				selosEtaria[pItem.classificaoEtaria[i]].Enable();
		}

		if(pItem.outros != null && pItem.outros.Length > 0)
		{
			for(int i = 0; i < pItem.outros.Length; i++)
				selosOutros[pItem.outros[i]].Enable();
		}

		if(pItem.usoProdutos != null && pItem.usoProdutos.Length > 0)
		{
			for(int i = 0; i < pItem.usoProdutos.Length; i++)
				selosUsoProduto[pItem.usoProdutos[i]].Enable();
		}

		if(pItem.publico != null && pItem.publico.Length > 0)
		{
			for(int i = 0; i < pItem.publico.Length; i++)
				selosPublico[pItem.publico[i]].Enable();
		}
	}

	public void DisableAll()
	{
		for(int i = 0; i < selosList.Count; i++)
		{
			selosList[i].Disable();
		}
	}
}
