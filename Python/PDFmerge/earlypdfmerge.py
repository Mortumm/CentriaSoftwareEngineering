import os
import sys
from PyQt5.QtWidgets import QApplication, QFileDialog, QMainWindow
from PyPDF2 import PdfFileMerger, PdfFileReader

class MainWindow(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("PDF Merger")
        self.setGeometry(100, 100, 400, 300)
        self.file_paths = []
        self.merger = PdfFileMerger()

    def open_file_dialog(self):
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        files, _ = QFileDialog.getOpenFileNames(self,"Select PDF Files", "","PDF Files (*.pdf)", options=options)
        if files:
            self.file_paths = files
            for file_path in self.file_paths:
                self.merger.append(PdfFileReader(file_path), 'rb')

    def save_file_dialog(self):
        options = QFileDialog.Options()
        options |= QFileDialog.DontUseNativeDialog
        file_name, _ = QFileDialog.getSaveFileName(self,"Save Merged PDF", "","PDF Files (*.pdf)", options=options)
        if file_name:
            self.merger.write(file_name)

    def move_up(self):
        current_row = self.listWidget.currentRow()
        if current_row > 0:
            item = self.listWidget.takeItem(current_row)
            self.listWidget.insertItem(current_row - 1, item)
            self.merger.movePage(current_row, current_row - 1)

    def move_down(self):
        current_row = self.listWidget.currentRow()
        if current_row < self.listWidget.count() - 1:
            item = self.listWidget.takeItem(current_row)
            self.listWidget.insertItem(current_row + 1, item)
            self.merger.movePage(current_row, current_row + 1)

if __name__ == "__main__":
    app = QApplication(sys.argv)
    window = MainWindow()
    window.show()

    app.exec_()
