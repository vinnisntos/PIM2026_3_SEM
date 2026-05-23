// PimEstoque - JavaScript Utilitário

document.addEventListener('DOMContentLoaded', function() {
    const sidebarToggle = document.querySelector('.sidebar-toggle');
    const sidebarCloseButtons = document.querySelectorAll('[data-sidebar-close]');

    if (sidebarToggle) {
        sidebarToggle.addEventListener('click', function() {
            document.body.classList.toggle('sidebar-open');
        });
    }

    sidebarCloseButtons.forEach(button => {
        button.addEventListener('click', function() {
            document.body.classList.remove('sidebar-open');
        });
    });

    document.querySelectorAll('.sidebar .nav-link').forEach(link => {
        link.addEventListener('click', function() {
            document.body.classList.remove('sidebar-open');
        });
    });

    window.addEventListener('resize', function() {
        if (window.innerWidth > 768) {
            document.body.classList.remove('sidebar-open');
        }
    });

    // Inicializar tooltips do Bootstrap
    var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
    var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
        return new bootstrap.Tooltip(tooltipTriggerEl);
    });

    // Adicionar animação aos cards ao carregar
    const cards = document.querySelectorAll('.card');
    cards.forEach((card, index) => {
        card.style.animationDelay = `${index * 0.1}s`;
    });

    // Confirmação para deletar (segurança adicional)
    const deleteButtons = document.querySelectorAll('a[href*="/Delete/"]');
    deleteButtons.forEach(button => {
        button.addEventListener('click', function(e) {
            if (!confirm('Tem certeza que deseja deletar este item? Esta ação não pode ser desfeita.')) {
                e.preventDefault();
            }
        });
    });

    // Auto-hide de alertas após 5 segundos
    const alerts = document.querySelectorAll('.alert:not(.alert-dismissible)');
    alerts.forEach(alert => {
        setTimeout(() => {
            const bsAlert = new bootstrap.Alert(alert);
            bsAlert.close();
        }, 5000);
    });

    console.log('PimEstoque - Sistema inicializado com sucesso!');
});

// Função auxiliar para formatar datas
function formatarData(data) {
    const d = new Date(data);
    return d.toLocaleDateString('pt-BR') + ' ' + d.toLocaleTimeString('pt-BR');
}

// Função auxiliar para validar formulários
function validarFormulario(formId) {
    const form = document.getElementById(formId);
    if (form) {
        return form.checkValidity() === false ? false : true;
    }
    return true;
}
