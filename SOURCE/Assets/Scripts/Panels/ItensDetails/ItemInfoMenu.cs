using UnityEngine;
using System.Collections;

public class ItemInfoMenu : MonoBehaviour 
{
	public ItemDetailsPanel itemDetailPanel;

	public TweenPosition tween;

	public NewBaseButton openButton;
	public NewBaseButton closeButton;

	public NewBaseButton informacaoButton;
	public NewBaseButton texturaButton;
	public NewBaseButton atributosButton;
	public NewBaseButton cabecaButton;
	public NewBaseButton valorizacaoButton;
	public NewBaseButton etariaButton;
	public NewBaseButton outrosButton;
	public NewBaseButton usoProdutoButton;
	public NewBaseButton publicoButton;
	
	public int enabledOptionsCount;

	void Awake()
	{
		openButton.AddOnClickListener(OnClickOpenInfo);
		closeButton.AddOnClickListener(OnClickCloseInfo);
		informacaoButton.AddOnClickListener(OnClickInformacoes);
		texturaButton.AddOnClickListener(OnClickTextura);
		atributosButton.AddOnClickListener(OnClickAtributos);
		cabecaButton.AddOnClickListener (OnClickCabeca);
		valorizacaoButton.AddOnClickListener(OnClickValorizacao);
		etariaButton.AddOnClickListener(OnClickClassificacaoEtaria);
		outrosButton.AddOnClickListener(OnClickOutros);
		usoProdutoButton.AddOnClickListener(OnClickUsoProdutos);
		publicoButton.AddOnClickListener(OnClickPublico);
	}

	public void OnOpen(ItemSettings pItem)
	{
		enabledOptionsCount = 1;

		if(pItem.texturas != null && pItem.texturas.Length > 0)
		{
			texturaButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			texturaButton.DisableButton();

		if(pItem.atributos != null && pItem.atributos.Length > 0)
		{
			atributosButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			atributosButton.DisableButton();

		if(pItem.cabecas != null && pItem.cabecas.Length > 0)
		{
			cabecaButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			cabecaButton.DisableButton();


		if(pItem.valorizacao != null && pItem.valorizacao.Length > 0)
		{
			valorizacaoButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			valorizacaoButton.DisableButton();

		if(pItem.classificaoEtaria != null && pItem.classificaoEtaria.Length > 0)
		{
			etariaButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			etariaButton.DisableButton();

		if(pItem.outros != null && pItem.outros.Length > 0)
		{
			outrosButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			outrosButton.DisableButton();

		if(pItem.usoProdutos != null && pItem.usoProdutos.Length > 0)
		{
			usoProdutoButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			usoProdutoButton.DisableButton();

		if(pItem.publico != null && pItem.publico.Length > 0)
		{
			publicoButton.EnableButton();
			enabledOptionsCount++;
		}
		else
			publicoButton.DisableButton();

		tween.to.y = (enabledOptionsCount) * (70.0f);
	}

	public void OnShow()
	{
		tween.PlayForward();
		openButton.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(true);
	}

	public void OnHide()
	{
		tween.PlayReverse();
		openButton.gameObject.SetActive(true);
		closeButton.gameObject.SetActive(false);
	}

	public void OnClickOpenInfo()
	{
		OnShow();
	}

	public void OnClickCloseInfo()
	{
		OnHide();
	}

	public void ShowInfoPanel(string pOptName)
	{
		itemDetailPanel.ShowInfoPanel(pOptName);
		OnHide();
	}

	public void OnClickInformacoes()
	{
		ShowInfoPanel("Informacao");
	}

	public void OnClickTextura()
	{
		ShowInfoPanel("Textura");
	}

	public void OnClickAtributos()
	{
		ShowInfoPanel("Atributo");
	}

	public void OnClickCabeca()
	{
		ShowInfoPanel("Cabeca");
	}

	public void OnClickValorizacao()
	{
		ShowInfoPanel("Valorizacao");
	}

	public void OnClickClassificacaoEtaria()
	{
		ShowInfoPanel("ClassificacaoEtaria");
	}

	public void OnClickOutros()
	{
		ShowInfoPanel("Outros");
	}

	public void OnClickUsoProdutos()
	{
		ShowInfoPanel("UsoProdutos");
	}

	public void OnClickPublico()
	{
		ShowInfoPanel("Publico");
	}
}
