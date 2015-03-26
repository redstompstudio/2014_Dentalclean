﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDetailsPanel : NewBasePanel
{
	public static ItemDetailsPanel instance;

	public int tweensPlayingCount;

	public UnityEngine.UI.Image itemImage;
	public UnityEngine.UI.Image logoImage;

	public Text infoText;
	public GameObject listTexturas;
	public GameObject listAtributos;
	public GameObject listCabecas;
	public GameObject listValorizacao;
	public GameObject listClassificacaoEtaria;
	public GameObject listOutros;
	public GameObject listUsoProdutos;
	public GameObject listPublico;

	public ItemInfoMenu infoMenu;

	public NewBaseButton exitButton;

	public UITweener[] tweens;

	protected override void Awake ()
	{
		instance = this;
		base.Awake();

		exitButton.AddOnClickListener(Hide);
	}

	public override void Show ()
	{
		panelGO.SetActive(true);
		panelImage.enabled = true;

		if(tweens != null && tweens.Length > 0)
		{
			tweensPlayingCount = 0;
			for(int i = 0; i < tweens.Length; i++)
			{
				if(tweens[i] != null)
				{
					tweens[i].onFinished.Clear();
					tweens[i].AddOnFinished(OnFinishedShowing);
					tweens[i].PlayForward();
					tweensPlayingCount++;
				}
			}
		}

		NewUIManager.Instance.AddBackButtonDelegate(Hide);

		base.Show ();
	}

	public void Show (ItemSettings pItem)
	{
		infoMenu.OnOpen(pItem);

		infoText.text = pItem.itemInformationText;
		itemImage.sprite = pItem.catalogImage;
		logoImage.sprite = pItem.logoImage;

		LabelsDataBase.Instance.EnableSelos(pItem);
		DisableAllInfoPanels();

		NewUIManager.Instance.EnablePanel(panelName);
	}

	public override void Hide ()
	{
		if(tweens != null && tweens.Length > 0)
		{
			tweensPlayingCount = 0;
			for(int i = 0; i < tweens.Length; i++)
			{
				tweens[i].onFinished.Clear();
				tweens[i].AddOnFinished(OnFinishedHiding);
				tweens[i].PlayReverse();
				tweensPlayingCount++;
			}
		}

		base.Hide();

//		panelGO.SetActive(false);
//		panelImage.enabled = false;
	}

	public void ShowInfoPanel(string pInfoName)
	{
		DisableAllInfoPanels();

		switch(pInfoName)
		{

		case "Informacao":
			infoText.gameObject.SetActive(true);
			break;

		case "Textura":
			listTexturas.SetActive(true);
			break;

		case "Atributo":
			listAtributos.SetActive(true);
			break;

		case "Cabeca":
			listCabecas.SetActive(true);
			break;

		case "Valorizacao":
			listValorizacao.SetActive(true);
			break;

		case "ClassificacaoEtaria":
			listClassificacaoEtaria.SetActive(true);
			break;

		case "Outros":
			listOutros.SetActive(true);
			break;

		case "UsoProdutos":
			listUsoProdutos.SetActive(true);
			break;

		case "Publico":
			listPublico.SetActive(true);
			break;
		}
	}

	void DisableAllInfoPanels()
	{
		infoText.gameObject.SetActive(false);
		listTexturas.SetActive(false);
		listAtributos.SetActive(false);
		listCabecas.SetActive(false);
		listValorizacao.SetActive(false);
		listClassificacaoEtaria.SetActive(false);
		listOutros.SetActive(false);
		listUsoProdutos.SetActive(false);
		listPublico.SetActive(false);
	}

	public void OnFinishedShowing()
	{
		tweensPlayingCount--;
	}

	public void OnFinishedHiding()
	{
		tweensPlayingCount--;

		if(tweensPlayingCount == 0)
		{
			panelGO.SetActive(false);
			panelImage.enabled = false;
		}
	}
}
