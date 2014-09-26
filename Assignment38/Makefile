all: ahaq_mikx_ppho_AS.38.pdf

ahaq_mikx_ppho_AS.38.pdf: ahaq_mikx_ppho_AS.38.tex dynamicmodel.tex staticmodel.tex
	pdflatex ahaq_mikx_ppho_AS.38.tex dynamicmodel.tex staticmodel.tex

clean:
	rm -f *.ps *.pdf *.aux *.dvi *.log *.out *~
